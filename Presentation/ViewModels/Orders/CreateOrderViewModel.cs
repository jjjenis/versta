using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Orders;

public sealed class CreateOrderViewModel
{
    [Required(ErrorMessage = "Укажите город отправителя")]
    [StringLength(100)]
    [Display(Name = "Город отправителя")]
    public string SenderCity { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите адрес отправителя")]
    [StringLength(250)]
    [Display(Name = "Адрес отправителя")]
    public string SenderAddress { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите город получателя")]
    [StringLength(100)]
    [Display(Name = "Город получателя")]
    public string RecipientCity { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите адрес получателя")]
    [StringLength(250)]
    [Display(Name = "Адрес получателя")]
    public string RecipientAddress { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите вес груза")]
    [Range(1, int.MaxValue, ErrorMessage = "Вес груза должен быть больше 0")]
    [Display(Name = "Вес груза, кг")]
    public int CargoWeight { get; set; }

    [Required(ErrorMessage = "Укажите дату забора груза")]
    [DataType(DataType.DateTime)]
    [Display(Name = "Дата забора груза")]
    public DateTime PickupDate { get; set; } = DateTime.Now;
}