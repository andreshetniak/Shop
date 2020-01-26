using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(5)]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Длинна имени не менее 5 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [DataType(DataType.Text)]
        public string SurName { get; set; }

        [Display(Name = "Введите адресс")]
        public string Adress { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> OrderDitails { get; set; }
    }
}
