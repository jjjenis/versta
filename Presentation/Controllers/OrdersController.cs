using Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Orders;

namespace Presentation.Controllers;

public class OrdersController(IOrderService orderService) : Controller
{
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var orders = await orderService.GetAllAsync(cancellationToken);

        return View(orders);
    }

    public IActionResult Create()
    {
        return View(new CreateOrderViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        CreateOrderViewModel model,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var request = new CreateOrderRequest(
            model.SenderCity,
            model.SenderAddress,
            model.RecipientCity,
            model.RecipientAddress,
            model.CargoWeight,
            model.PickupDate);

        var order = await orderService.CreateAsync(request, cancellationToken);

        return RedirectToAction(nameof(Details), new { id = order.Id });
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var order = await orderService.GetByIdAsync(id, cancellationToken);

        if (order is null)
        {
            return NotFound();
        }

        return View(order);
    }
}