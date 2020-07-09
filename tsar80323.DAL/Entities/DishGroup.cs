﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tsar80323.DAL.Entities
{
  public  class DishGroup
    {
        public int DishGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Dish> Dishes { get; set; }
    }
}
