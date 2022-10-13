﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Domain;

public class Package
{
    public int PackageId { get; set; }
    public string? Name { get; set; }
    public int? CityId { get; set; }
    public int? CafeteriaId { get; set; }
    public virtual Cafeteria? Cafeteria { get; set; }
    public DateTime? PickupTime { get; set; }
    public DateTime? BestBeforeDate { get; set; }
    public bool? EighteenPlus { get; set; }
    public decimal? Price { get; set; }
    public Category? Category { get; set; }
    public int? ReservedByStudentId { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
    public virtual City? City { get; set; }
}

public enum Category
{
    Fruit,
    Vegetable,
    Bread,
    Diner,
    Lunch,
    Beveridge,
    HotMeal,
    Vega,
    Gluten,
}