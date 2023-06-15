using Future.Context;
using Future.Models;
using System.Reflection;
using System.Text;


namespace FPOSMenuMaker.Services
{
    internal class CurrentItemSelectionHandler
    {
        private FPOSContext _context { get; set; }
        private Pages.Index? _index;
        public Item? currentSelection { get; private set; }
        public ItemPrice currentItemPrice { get; private set; }
        public Department currentDepartmentSelection { get; private set; }

        public CurrentItemSelectionHandler(FPOSContext context)
        {
            _context = context;
            SetCurrentSelection(GetAllItems().FirstOrDefault()?.ItemId.ToString());
        }

        public List<Item> GetAllItems()
        {
            var items = _context.Items.ToList();
            items.Sort((a, b) => a.ItemName.CompareTo(b.ItemName));
            return items;
        }

        public List<(string, List<Item>)> SplitItemsByDepartment()
        {
            List<(string, List<Item>)> DepartmentItems = new List<(string, List<Item>)>();
            var departements = _context.Departments.ToList();
            foreach (Department dep in departements)
            {
                var items = _context.Items.Where((item) => item.Department == dep.DepartmentName).ToList();
                DepartmentItems.Add((dep.DepartmentName, items));
            }
            return DepartmentItems;
        }

        public void SetCurrentSelection(string? itemId)
        {
            if (itemId is null)
            {
                CreateNewItem();
                return;
            }
            if (currentSelection is not null)
            {
                _context.Entry(currentSelection).Reload();
            }
            currentSelection = _context.Items.FirstOrDefault((item) => item.ItemId.ToString() == itemId);
            _context.Entry<Item>(currentSelection!).Reload();
            SetItemBasePrice();
            SetCurrentDepartmentSelection(currentSelection!.Department);
        }

        public void SetCurrentDepartmentSelection(string department)
        {
            if (department == "All Departments")
            {
                currentDepartmentSelection = new Department()
                {
                    DepartmentName = "All Departments",
                    DepartmentId = Guid.NewGuid(),
                };
            }
            else
            {
                var dep = _context.Departments.Where(dep => dep.DepartmentName == department).ToList();
                if (dep.Any())
                {
                    currentDepartmentSelection = dep.First();
                }
                else
                {
                    currentDepartmentSelection = _context.Departments.First();
                    currentSelection.Department = currentDepartmentSelection.DepartmentName;
                }
            }
        }
        public Guid GetDepartmentDefaultItem(string departmentName)
        {
            var departmentItems = _context.Items.Where(item => item.Department == departmentName).ToList();
            if (departmentItems.Any())
            {
                departmentItems.Sort((a, b) => a.Department.CompareTo(b.Department));
                return departmentItems[0].ItemId;
            }
            else
            {
                return Guid.Empty;
            }
        }
        public void SetItemBasePrice()
        {
            var prices = _context.ItemPrices.Where((price) => price.ItemId == currentSelection.ItemId && price.ScheduleIndex == 0).ToList();
            if (!prices.Any())
            {
                CreateNewDefaultItemPrice();
            }
            else
            {
                currentItemPrice = prices.First();
            }
        }
        public List<Department> GetDepartments()
        {
            var departments = _context.Departments.ToList();
            departments.Sort((a, b) => a.DepartmentName.CompareTo(b.DepartmentName));
            return departments;
        }

        public List<Item> GetDepartmentItems(string departmentName)
        {
            if (departmentName == "All Departments")
            {
                return GetAllItems();
            }
            else
            {
                return _context.Items.Where(item => item.Department == departmentName).ToList();
            }

        }
        private void CreateNewDefaultItemPrice()
        {
            currentItemPrice = new ItemPrice()
            {
                ItemPriceId = Guid.NewGuid(),
                ItemId = currentSelection!.ItemId,
                ScheduleIndex = 0,
                DefaultPrice = 0,
            };
            foreach (PropertyInfo prop in currentItemPrice.GetType().GetProperties())
            {
                if (prop.Name.Contains("Level"))
                {
                    prop.SetValue(currentItemPrice, 0);
                }
            }
            _context.ItemPrices.Add(currentItemPrice);
            Save();
        }
        public ItemPrice CreateNewItemPrice(int scheduleIndex)
        {
            var price = _context.ItemPrices.Where((price) => price.ScheduleIndex == scheduleIndex && price.ItemId == currentSelection!.ItemId).FirstOrDefault();
            if (price is not null)
            {
                return price;
            }
            else
            {
                var newPrice = new ItemPrice()
                {
                    ItemPriceId = Guid.NewGuid(),
                    ItemId = currentSelection!.ItemId,
                    ScheduleIndex = scheduleIndex,
                    DefaultPrice = 0,
                };
                foreach (PropertyInfo prop in newPrice.GetType().GetProperties())
                {
                    if (prop.Name.Contains("Level"))
                    {
                        prop.SetValue(newPrice, 0);
                    }
                }
                _context.ItemPrices.Add(newPrice);
                _context.SaveChanges();
                return newPrice;
            }
        }
        public List<Item> GetCurrentItemModifiers()
        {
            var itemMods = (from item in _context.Items
                            join mod in (from i in _context.ItemModifiers where i.ItemId == currentSelection.ItemId select i)
                            on item.ItemName equals mod.ModifierName
                            select item).ToList();

            return itemMods;
        }
        public List<ItemPrice> GetItemPrices()
        {
            var itemPrices = _context.ItemPrices.Where(price => price.ItemId == currentSelection.ItemId);
            if (itemPrices.Any())
            {
                return itemPrices.ToList();
            }
            else
            {
                return new List<ItemPrice>();
            }
        }

        public List<PriceLevel> GetPriceLevelInfo()
        {
            var priceLevels = _context.PriceLevels;
            if (priceLevels.Any())
            {
                return priceLevels.ToList();
            }
            else
            {
                return new List<PriceLevel>();
            }
        }

        public bool PriceScheduleIndexExists(int index)
        {
            var sched = _context.PriceSchedules.Where(s => s.PriceScheduleIndex == index).ToList();
            if (sched.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PriceSchedule> GetPriceScheduleInfo()
        {
            var priceSchedules = _context.PriceSchedules;
            if (priceSchedules.Any())
            {
                return priceSchedules.ToList();
            }
            else
            {
                return new List<PriceSchedule>();
            }
        }

        public ItemPrice? GetDefaultPrice()
        {
            if (!_context.ItemPrices.Where(price => price.ItemId == currentSelection!.ItemId && price.ScheduleIndex == 0).Any())
            {
                CreateNewDefaultItemPrice();
            }
            var price = _context.ItemPrices.FirstOrDefault(price => price.ItemId == currentSelection!.ItemId && price.ScheduleIndex == 0);
            return price;
        }

        public bool HasMods()
        {
            var mods = (from mod in _context.ItemModifiers
                        where mod.ItemId == currentSelection.ItemId
                        select mod).ToList();

            return mods.Any();
        }
        public List<Item> GetAllItemModifiers(bool filterMods, bool filterModGroups)
        {
            List<Item> mods;
            if (filterMods && filterModGroups)
            {
                mods = _context.Items.Where((item) => item.IsModifier == true && item.IsModifierGroup == true).ToList();
            }
            else if (filterMods)
            {
                mods = _context.Items.Where((item) => item.IsModifier == true).ToList();
            }
            else if (filterModGroups)
            {
                mods = _context.Items.Where((item) => item.IsModifierGroup == true).ToList();
            }
            else
            {
                mods = _context.Items.ToList();
            }
            mods.Sort((a, b) => a.ItemName.CompareTo(b.ItemName));
            return mods;
        }
        public List<Item> GetItemModifiers()
        {
            return _context.Items.Where((item) => item.IsModifier == true).ToList();
        }

        public List<Item> GetItemModifierGroups()
        {
            return _context.Items.Where((item) => item.IsModifierGroup == true).ToList();
        }
        public void RemoveModFromSelection(string itemName)
        {
            var mod = _context.ItemModifiers.FirstOrDefault((item) => item.ModifierName == itemName && item.ItemId == currentSelection.ItemId);
            if (mod is not null)
            {
                _context.ItemModifiers.Remove(mod);
                currentSelection.ModifierCount--;
                Save();
            }
        }
        public void AddModToSelection(string modName)
        {
            var itemMod = new ItemModifier()
            {
                ItemModifierId = Guid.NewGuid(),
                ItemId = currentSelection.ItemId,
                ModifierIndex = GetNextModifierIndex(currentSelection.ItemId),
                Item = currentSelection,
                ModifierName = modName
            };
            _context.ItemModifiers.Add(itemMod);
            currentSelection.ModifierCount++;
            Save();
        }
        public int GetNextModifierIndex(Guid itemId)
        {
            int index = 0;
            var mods = _context.ItemModifiers.Where(mod => mod.ItemId == itemId);
            if (mods.Any())
            {
                index = mods.Max(mod => mod.ModifierIndex) + 1;
            }
            return index;
        }

        public List<Tax> GetTaxInfo()
        {
            return _context.Taxes.ToList();
        }
        public byte GetTaxFlags()
        {
            byte flags = 0;
            if (currentSelection is not null)
            {
                flags = currentSelection.TaxFlags;
            }
            return flags;
        }
        public void SetTaxFlags(byte flags)
        {
            if (currentSelection is not null)
            {
                currentSelection.TaxFlags = flags;
                Save();
            }
        }
        public void CreateNewItem()
        {
            var newItemExists = _context.Items.Where((item) => item.ItemName == "New Item");
            if (newItemExists.Any())
            {
                _context.Items.Remove(newItemExists.First());
                Save();
            }
            short z = 0;
            var id = Guid.NewGuid();
            var newItem = new Item()
            {
                ItemId = id,
                ItemName = "New Item",
                Upc = "",
                ItemCount = -1,
                ItemDescription = "New Item",
                ReceiptDesc = "New Item",
                AlternateItem = "",
                DiscountFlags = BitConverter.GetBytes(z),
                Department = _context.Departments.First().DepartmentName,
            };
            if (currentSelection is not null)
            {
                _context.Entry(currentSelection).Reload();
            }
            _context.Items.Add(newItem);
            Save();
            SetCurrentSelection(newItem.ItemId.ToString());
            Save();
            Update();
        }

        public bool CreateNewItem(string itemName, string department)
        {
            var existingItem = _context.Items.FirstOrDefault((item) => item.ItemName == itemName);
            if (existingItem is not null)
            {
                return false;
            }
            short z = 0;
            var id = Guid.NewGuid();
            var newItem = new Item()
            {
                ItemId = id,
                ItemName = itemName,
                Upc = "",
                ItemCount = -1,
                ItemDescription = "New Item",
                ReceiptDesc = "New Item",
                AlternateItem = "",
                DiscountFlags = BitConverter.GetBytes(z),
                Department = department,
            };
            if (currentSelection is not null)
            {
                _context.Entry(currentSelection).Reload();
            }
            _context.Items.Add(newItem);
            Save();
            SetCurrentSelection(newItem.ItemId.ToString());
            SetItemBasePrice();
            Save();
            Update();
            return true;
        }
        public Future.Models.Button? GetMenuButtonStyles(string menuName, int position)
        {
            var ceil = Math.Ceiling((float)position / 5f) * 5;
            var floor = (Math.Floor((float)position / 5f) * 5) + 1;
            var menuButtons = _context.Buttons.Where((button) => button.Menu == menuName).ToList();
            if (menuButtons is not null)
            {
                var rowButtons = menuButtons.Where((button) => button.Position >= floor && button.Position <= ceil).ToList();
                if (rowButtons.Any())
                {
                    return rowButtons.First();
                }
                else
                {
                    return menuButtons.First();
                }
            }
            else
            {
                return null;
            }

        }
        public void CreateMenuButton(string menuName, string itemName)
        {
            var data = CreateDataField(itemName);
            var index = GetNextAvaliableMenuIndex(menuName);
            var buttonStyles = GetMenuButtonStyles(menuName, index);
            var newMenu = new Future.Models.Button()
            {
                ButtonId = Guid.NewGuid(),
                RegionId = Guid.Empty,
                Menu = menuName,
                ButtonName = itemName,
                Data = data,
                Function = 5, // FIND MENU BUTTON FUNCTION
                Position = index, // CREATE FUNCTION TO FIND NEXT AVALIABLE INDEX
                Width = buttonStyles?.Width ?? GetDefaultButtonWidth(),
                Height = buttonStyles?.Height ?? GetDefaultButtonHeight(),
                Text = _context.Items.FirstOrDefault((item) => item.ItemName == itemName)?.ItemDescription ?? "",
                ForeGround = buttonStyles?.ForeGround ?? 16777215,
                BackGround = buttonStyles?.BackGround ?? 12632256,
                FontFaceName = buttonStyles?.FontFaceName ?? "Arial",
                NoBorder = buttonStyles?.NoBorder ?? 1,
                FontPitchAndFamily = buttonStyles?.FontPitchAndFamily ?? 34,
                FontWeight = buttonStyles?.FontWeight ?? 700,
                FontHeight = buttonStyles?.FontHeight ?? -16,
                FontOutPrecision = buttonStyles?.FontOutPrecision ?? 3,
                FontClipPrecision = buttonStyles?.FontClipPrecision ?? 2,
                FontQuality = buttonStyles?.FontQuality ?? 1,
                GraphicName = buttonStyles?.GraphicName ?? string.Empty,
            };
            _context.Buttons.Add(newMenu);
            Save();
        }

        public short GetDefaultButtonWidth()
        {
            var width = _context.Configurations.FirstOrDefault((config) => config.Parameter == "DefaultButtonWidth")?.Value;
            if (width is not null && width != "")
            {
                return Int16.Parse(width);
            }
            else
            {
                return 55;
            }
        }

        public short GetDefaultButtonHeight()
        {
            var height = _context.Configurations.FirstOrDefault((config) => config.Parameter == "DefaultButtonHeight")?.Value;
            if (height is not null && height != "")
            {
                return Int16.Parse(height);
            }
            else
            {
                return 55;
            }
        }

        public byte GetNextAvaliableMenuIndex(string menuName)
        {
            var range = Enumerable.Range(1, 255).ToHashSet();
            var byteRange = range.SelectMany(BitConverter.GetBytes).ToHashSet();
            var occupiedPositions = _context.Buttons.Where((button) => button.Menu == menuName).Select((button) => button.Position).ToHashSet();
            occupiedPositions.Add(0);
            var availiablePostions = byteRange.Except(occupiedPositions).ToList();
            return availiablePostions.Min();
        }

        private Byte[] CreateDataField(string itemName)
        {
            var bytes = new Byte[512];
            var encodedData = Encoding.UTF8.GetBytes(itemName);
            bytes[2] = 1;
            System.Array.Copy(encodedData, 0, bytes, 32, encodedData.Length);
            return bytes;
        }

        public bool ItemButtonExists()
        {
            var button = _context.Buttons.FirstOrDefault((button) => button.ButtonName == currentSelection!.ItemName);
            if (button is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeleteButton()
        {
            var exists = ItemButtonExists();
            if (exists)
            {
                var button = _context.Buttons.FirstOrDefault((button) => button.ButtonName == currentSelection!.ItemName);
                _context.Buttons.Remove(button!);
                _context.SaveChanges();
            }
        }

        public void DeleteButton(string itemName)
        {
            var button = _context.Buttons.FirstOrDefault((button) => button.ButtonName == itemName);
            if (button is not null)
            {
                _context.Buttons.Remove(button);
            }
        }

        public List<string> GetMenuNames()
        {
            HashSet<string> menuNames = new HashSet<string>();
            var menuButtons = _context.Buttons.Where((button) => button.Function == 29).ToList();
            if (menuButtons.Any())
            {
                foreach (var button in menuButtons)
                {
                    var data = button.Data.Take(20).Where((b) => b != 0).ToArray();
                    var menuName = Encoding.UTF8.GetString(data);
                    menuNames.Add(menuName);
                }
            }
            var retVal = menuNames.ToList();
            retVal.Sort();
            return retVal;
        }
        public void Refresh(object entity)
        {
            _context.Entry(entity).Reload();
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
                Update();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }

        }
        public List<Discount> GetDiscounts()
        {
            return _context.Discounts.OrderBy((discount) => discount.DiscountIndex).ToList();
        }

        public void SetDiscountFlags(int offsetIndex, byte flags)
        {
            currentSelection.DiscountFlags[offsetIndex] = flags;
        }
        public byte[] GetDiscountFlags()
        {
            return currentSelection.DiscountFlags;
        }
        public List<ConfigurationDevice> GetAllPrinters()
        {
            var printers = _context.ConfigurationDevices.Where((device) => device.Type == 1).ToList();
            printers.Sort((a, b) => a.Number.CompareTo(b.Number));
            return printers;
        }

        public ConfigurationDevice? GetDevicePrinter(int printerIndex)
        {
            return _context.ConfigurationDevices.Where((device) => device.Type == 1 && device.Number == printerIndex).FirstOrDefault();
        }

        public ItemPrinter? GetItemPrinter(int index)
        {
            var printer = _context.ItemPrinters.Where(printer => printer.PrinterIndex == index && printer.ItemId == currentSelection!.ItemId).FirstOrDefault();
            return printer;
        }

        public void TogglePrinter(int printerIndex, string printDescription = "")
        {
            var printer = _context.ItemPrinters.FirstOrDefault((printer) => printer.PrinterIndex == printerIndex && printer.ItemId == currentSelection.ItemId);
            if (printer is null)
            {
                _context.ItemPrinters.Add(CreateNewItemPrinter(printerIndex, printDescription));
            }
            else
            {
                _context.ItemPrinters.Remove(printer);
            }
            Save();
        }

        public bool PrinterEnabled(int printerIndex)
        {
            return _context.ItemPrinters.FirstOrDefault(printer => printer.PrinterIndex == printerIndex && printer.ItemId == currentSelection.ItemId) is not null;
        }

        public string GetPrintDescription(int printerIndex)
        {
            var description = _context.ItemPrinters.Where((printer) => printer.PrinterIndex == printerIndex && printer.ItemId == currentSelection.ItemId).Select((printer) => printer.ReceiptDescription).FirstOrDefault() ?? "";
            return description;
        }

        public void SetPrintDescription(int index, string description)
        {
            var printer = _context.ItemPrinters.Where(printer => printer.PrinterIndex == index && printer.ItemId == currentSelection.ItemId).FirstOrDefault();
            if (printer is not null)
            {
                printer.ReceiptDescription = description;
                Save();
            }
        }

        private ItemPrinter CreateNewItemPrinter(int printerIndex, string printDescription)
        {
            var printer = new ItemPrinter()
            {
                PrinterIndex = printerIndex,
                ItemId = currentSelection!.ItemId,
                ItemPrinterId = Guid.NewGuid(),
                ReceiptDescription = printDescription
            };
            return printer;
        }
        public void Delete()
        {
            var oldSelection = currentSelection;
            var newSelection = _context.Items.FirstOrDefault(item => item.Department == currentSelection.Department && item.ItemId != currentSelection.ItemId);
            if (newSelection is not null)
            {
                SetCurrentSelection(newSelection.ItemId.ToString());
                _context.Entry<Item>(currentSelection!).Reload();
                DeleteButton(oldSelection!.ItemName);
                _context.Remove<Item>(oldSelection!);
                Save();
            }
            else
            {
                SetCurrentSelection(_context.Items.First().ItemId.ToString());
                _context.Entry<Item>(currentSelection!).Reload();
                DeleteButton(oldSelection!.ItemName);
                _context.Remove<Item>(oldSelection!);
                Save();
            }

        }

        public void SetIndex(Pages.Index index)
        {
            _index = index;
        }

        public void Update()
        {
            if (_index is not null)
            {
                _index.Update();
            }
        }
    }
}
