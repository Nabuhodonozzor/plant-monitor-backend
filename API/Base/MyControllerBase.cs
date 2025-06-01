namespace PlantMonitorAPI.API.Base;

using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class MyControllerBase : ControllerBase
{
    private IMediator? mediator;

    protected IMediator Mediator
    {
        get => this.mediator ??= this.HttpContext.RequestServices.GetRequiredService<IMediator>();
    }

    /// <summary>
    /// Wspólna metoda wysyłająca rządanie API do wykonania przez logikę biznesową
    /// </summary>
    /// <param name="request">Rządanie do wykonania przez logikę biznesową</param>
    /// <typeparam name="T">Typ danych</typeparam>
    /// <returns>Zadanie asynchronicznego przetwarzania dla zadanego rządania</returns>
    protected async Task<ActionResult<T>> Send<T>(IRequest<T> request)
    {
        return this.Ok(await this.Mediator.Send(request, this.HttpContext.RequestAborted));
    }

    /// <summary>
    /// Wspólna metoda wysyłająca rządanie API do wykonania przez logikę biznesową
    /// </summary>
    /// <param name="request">Rządanie do wykonania przez logikę biznesową</param>
    /// <returns>Zadanie asynchronicznego przetwarzania dla zadanego rządania</returns>
    protected async Task<ActionResult> Send(IRequest request)
    {
        await this.Mediator.Send(request, this.HttpContext.RequestAborted);
        return this.Ok();
    }
}
