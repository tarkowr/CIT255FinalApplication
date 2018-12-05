﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInsight.Model
{
    public enum MouseIcons
    {
        DEFAULT,
        LOADING
    }


    public class Context
    {
        public List<TickerSymbol> Watchlist { get; set; }
        public List<Stock> Stocks { get; set; } 

        public Context()
        {
            Watchlist = new List<TickerSymbol>();
            Stocks = new List<Stock>();
        }
    }
}
