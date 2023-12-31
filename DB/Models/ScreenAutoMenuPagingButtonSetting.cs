﻿using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class ScreenAutoMenuPagingButtonSetting
    {
        public Guid ScreenAutoMenuPagingButtonSettingsId { get; set; }
        public Guid ScreenAutoMenuId { get; set; }
        public byte? Order { get; set; }
        public byte? MinSecLevel { get; set; }
        public bool? AskForSupervisor { get; set; }
        public byte? ButtonTextSource { get; set; }
        public bool? ShowQuantityAvailable { get; set; }
        public short? Width { get; set; }
        public short? Height { get; set; }
        public short? FontHeight { get; set; }
        public short? FontWidth { get; set; }
        public short? FontEscapement { get; set; }
        public short? FontOrientation { get; set; }
        public short? FontWeight { get; set; }
        public byte? FontItalic { get; set; }
        public byte? FontUnderline { get; set; }
        public byte? FontStrikeout { get; set; }
        public byte? FontCharSet { get; set; }
        public byte? FontOutPrecision { get; set; }
        public byte? FontClipPrecision { get; set; }
        public byte? FontQuality { get; set; }
        public byte? FontPitchAndFamily { get; set; }
        public string? FontFaceName { get; set; }
        public int? ForeGround { get; set; }
        public int? BackGround { get; set; }
        public byte? GraphicsPosition { get; set; }
        public byte? GraphicsTextAlignment { get; set; }
        public string? GraphicName { get; set; }
        public byte? Border3D { get; set; }

        public virtual ScreenAutoMenu ScreenAutoMenu { get; set; } = null!;
    }
}
