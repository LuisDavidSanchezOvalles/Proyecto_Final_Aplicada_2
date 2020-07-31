using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ProyectoFinalAplicada2.BLL
{
    public static class JSBLL
    {
        public async static Task<bool> ConfirmDelete(this IJSRuntime js, string titulo, string Mensaje, string tipo)
        {
            return await js.InvokeAsync<bool>("ConfirmationPrumpt", titulo, Mensaje, tipo);
        }

        public async static Task<bool> Aceptar(this IJSRuntime js, string titulo, string Mensaje, string tipo)
        {
            return await js.InvokeAsync<bool>("Confirmation", titulo, Mensaje, tipo);
        }

        public async static Task<bool> Confirmar(this IJSRuntime js, string posicion, string icono, string titulo, string texto, bool confbtn, int timer)
        {
            return await js.InvokeAsync<bool>("SavePrumpt", posicion, icono, titulo, texto, confbtn, timer);
        }

        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
       => js.InvokeAsync<object>(
           "saveAsFile",
           filename,
           Convert.ToBase64String(data));
    }
}
