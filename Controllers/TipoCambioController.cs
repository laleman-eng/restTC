using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using restTC.Models;
using restTC.Repositories;

namespace restTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambioController : Controller
    {
        private ITipoCambioColletion db = new TipoCambioCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllTipoCambio()
        {
            return Ok(await db.GetAllTipoCambio());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoCambioDetails(string id)
        {
            return Ok(await db.GetTipoCambioById(id));
        }

        [HttpGet("tcbydate/{date}")]
        public async Task<IActionResult> GetTipoCambioByDate(string date)
        {
            return Ok(await db.GetTipoCambioByDate(date));
        }

        [HttpGet("tc")]
        public async Task<IActionResult> GetTipoCambio([FromBody] TipoCambio tipoCambio)
        {

            try
            {
                if (tipoCambio.fecha == null)
                {
                    ModelState.AddModelError("fecha", "Campo obligatorio");
                    return BadRequest();
                }

                if (tipoCambio.codigo == null)
                {
                    ModelState.AddModelError("fecha", "Campo obligatorio");
                    return BadRequest();
                }

                if (tipoCambio.fecha == string.Empty)
                {
                    ModelState.AddModelError("fecha", "La fecha no puede ser vacio");
                    return BadRequest();
                }

                if (tipoCambio.codigo == string.Empty)
                {
                    ModelState.AddModelError("codigo", "El codigo no puede ser vacio");
                    return BadRequest();
                }
                TipoCambio tc;

                tc = await db.GetTipoCambio(tipoCambio);
                if (tc == null)
                {
                    ModelState.AddModelError("codigo", "El codigo no puede ser vacio");
                    return BadRequest();
                }

                return Ok(tc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
     
        }


        [HttpPost]
        public async Task<IActionResult> CreateTipoCambio([FromBody] TipoCambio tipoCambio)
        {
            if (tipoCambio == null)
                return BadRequest();

            if (tipoCambio.fecha == string.Empty)
                ModelState.AddModelError("fecha", "La fecha no puede ser vacio");

            await db.InsertarTipoCambio(tipoCambio);
            return Created("creado", true);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoCambio([FromBody] TipoCambio tipoCambio, string id)
        {
            if (tipoCambio == null)
                return BadRequest();

            if (tipoCambio.fecha == string.Empty)
                ModelState.AddModelError("fecha", "La fecha no puede ser vacio");

            tipoCambio.Id = new ObjectId(id);            
            await db.UpdateTipoCambio(tipoCambio);
            
            return Created("modificado", true);
            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteTipoCambio(string id)
        {
            await db.DeleteTipoCambio(id);
            return NoContent();
        }


    }
}