using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using demobackend.Data;
using demobackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace demobackend.Controllers
{
        [Authorize]
        [Route("api/[controller]")]
        public class ManageCarController : Controller
        {
            private IMapper _mapper; 
            private ApplicationDbContext dbContext;
            public ManageCarController(IMapper mapper, ApplicationDbContext context)
            {
                this._mapper = mapper;
                this.dbContext = context;
            }
            // GET api/values
            [HttpGet]
            public IEnumerable<CarViewModel> Get()
            {
                IEnumerable<CarViewModel> list = this._mapper.Map<IEnumerable<CarViewModel>>(this.dbContext.cars.AsEnumerable());
                return list;
            }

            // GET api/values/5
            [HttpGet("{id}")]
            public  IActionResult Get(int id)
            {
                var _car = this._mapper.Map<CarViewModel>(this.dbContext.cars.Find(id));
                return Ok(_car);
            }

            // POST api/values
            [HttpPost]
            public IActionResult Post([FromBody] CarViewModel _car)
            {
               if (ModelState.IsValid)
                {
                    _car.Registered = DateTime.Now;
                    var newcar = this._mapper.Map<Car>(_car);
                    this.dbContext.cars.Add(newcar);
                    this.dbContext.SaveChanges();
                    return Ok();
                }else{
                    return BadRequest();
                }
            }

            // PUT api/values/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] CarViewModel value)
            {    
                if (ModelState.IsValid)
                {
                    var existingCar = this.dbContext.cars.Find(id);
                    if(existingCar == null){
                          return NotFound();
                     }else{  
                        existingCar.Name = value.Name;
                        existingCar.Mark = value.Mark;
                        existingCar.Model = value.Model;
                        this.dbContext.cars.Update(existingCar);
                        this.dbContext.SaveChanges();
                        return Ok();
                    }
                }else{
                    return BadRequest();
                }
            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                this.dbContext.cars.Remove(this.dbContext.cars.Find(id));
                this.dbContext.SaveChanges();
                return Ok();
            }
    }
}