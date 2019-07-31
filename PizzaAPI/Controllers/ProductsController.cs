using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using PizzaAPI.Models;
using PizzaAPI.Models.EntityRepository;
using Microsoft.AspNetCore.Cors;


namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsOrigin")]
    public class ProductsController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IProductRepository _cr;
        public  ProductsController(APIDbContext context, IProductRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;
            List<Category> cs = _context.Category.ToList<Category>();
            if (_context.Products.Count() == 0)
            {
                _context.Products.AddRange(new List<Product>(){
                    new Product
                    {
                        Category = cs[0],
                        CategoryID = cs[0].CategoryID,
                        Price = 8.00m,
                        SRC = "/imgs/MeatLoversBreakfastPizza.jpg",
                        Name = "Meat Lovers BreakFast",
                        Description = "Pepperoni, Canadian bacon, hand-pinched Italian sausage and applewood smoked bacon over homemade pizza sause, smothered in mozzarella.",
                        Calories = "1425 cal."
                    },
                    new Product
                    {
                        Category = cs[0],
                        CategoryID = cs[0].CategoryID,
                        Price = 8.00m,
                        SRC = "/imgs/pizza_puttanesca.jpg",
                        Name = "Puttanesca",
                        Description = "Spinach, bruschetta tomatoes, Italian sausage, extra mozzarella cheese, and sprinkled with parmesan cheese and spicy crushed red pepper.",
                        Calories = "960 cal."
                    },
                    new Product
                    {
                        Category = cs[0],
                        CategoryID = cs[0].CategoryID,
                        Price = 8.00m,
                        SRC = "/imgs/buffalochicken.jpg",
                        Name = "Buffalo Chicken",
                        Description = "Traditional crust, spicy buffalo sause, freshly grated mozzarella, all-ntural chicken breast, banana & red peppper, blue chees dressing, basil.",
                        Calories = "820 cal."
                    },
                    new Product
                    {
                        Category = cs[0],
                        CategoryID = cs[0].CategoryID,
                        Price = 8.00m,
                        SRC = "/imgs/thebeast.jpg",
                        Name = "The Beast",
                        Description = "Traditional crust, tomato blend, freshly grated mozzarella, pepperoni, ham, bacon, sausage.",
                        Calories = "1197 cal."
                    },
                    new Product
                    {
                        Category = cs[0],
                        CategoryID = cs[0].CategoryID,
                        Price = 8.00m,
                        SRC = "/imgs/thebeast.jpg",
                        Name = "The Vegan",
                        Description = "Rosemary herb crust, tomato blend, minced garlic, vegan cheese, vegan sausage crumble, red onion, roasted red pepper, garlic, roasted broccoli, truffle salt, basil.",
                        Calories = "550 cal."
                    },
                    new Product
                    {
                        Category = cs[0],
                        CategoryID = cs[0].CategoryID,
                        Price = 8.00m,
                        SRC = "/imgs/VeggiePizza.jpg",
                        Name = "The Vegetarian",
                        Description = "Green peppers, mushrooms, black olives, tomatoes and onions over our homemade pizza sauce, smothered in mozzarella.",
                        Calories = "680 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/Calzone_MeatLovers.jpg",
                        Name = "Meat Lovers",
                        Description = "Thinly sliced steak, sauteed onion and green peppers, fresh mushrooms and our signature gourmet cheese blend smothered in homemade tomato sauce and wrapped in a golden-browncrust, brushed with rich grarlic butter and sprinkled Parmesan cheese",
                        Calories = "1620 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/BuffaloChickenCalzone.jpg",
                        Name = "Buffalo Chicken",
                        Description = "Buffalo Sauce, Mozzarella, Spicy Chicken, Tomatoes, Arugula.",
                        Calories = "1160 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/SpinachRicottaSausageCalzone.jpg",
                        Name = "Spinach Ricotta & Sausage",
                        Description = "Classic Red, Mozzarella, Pepperoni, Sausage, Green Pepper, Red Onion, Mushrooms.",
                        Calories = "1250 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/CheesySausageCalzone.jpg",
                        Name = "Chicken & Sausage",
                        Description = "Spicy Italian sausage, tender green peppers and onions, our signature gourmet cheese blend and homemade tomato sauce wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese.",
                        Calories = "1450 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/ham-and-cheese-calzone.jpg",
                        Name = "Ham & Cheese",
                        Description = "Mozzarella, Cheddar Jack, Ricotta, Ham",
                        Calories = "1334 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/Cheese_Mushroom_Calzone_-_(1865)_.jpg",
                        Name = "Cheese & Mushroom",
                        Description = "Ranch, Mozzarella, Chicken, Bacon, Red Pepper, Green Onion, Mushrooms",
                        Calories = "1309 cal."
                    },
                    new Product
                    {
                        Category = cs[2],
                        CategoryID = cs[2].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/chickenbasilcalzones.jpg",
                        Name = "Chicken & Basil",
                        Description = "Tender grilled white chicken meat, fresh tomatoes, sauteed onions and green pepper, crispy bacon and Sarpino's signature gourmet cheese blend wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1290 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/Chicken_Parm_Stromboli.jpg",
                        Name = "Chicken Parmesian",
                        Description = "Tender grilled white chicken meat, fresh tomatoes, sauteed onions and green peppers, crispy bacon and Sarpino's signature gourmet cheese blend wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1145 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/Meat-Lovers-Stromboli.jpg",
                        Name = "Meat Lovers",
                        Description = "Piping hot meatballs smothered in our signature gourmet cheese blend and famous homemade tomato sauce, and wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1680 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/Garlic Butter Stromboli.jpg",
                        Name = "Garlic Butter",
                        Description = "Sliced meatballs, spicy Italian sausage, sauteed onions and green peppers, our signature gourmet cheese blend and homemade tomato sauce wrapped in a goldenbrown crust, brushed with rich garlic butter and sprinkled Parmesan cheese.",
                        Calories = "1658 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/PhillyCheeseSteakStromboli.jpg",
                        Name = "PHILLY CHEESE STEAK",
                        Description = "Thinly sliced steak, sauteed onions and green peppers, fresh mushrooms and our signature gourmet cheese blend smothered in homemade tomato sauce and wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1740 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/stromboli-Sausage-Pepperoni.jpg",
                        Name = "SAUSAGE & PEPPERONI",
                        Description = "Spicy Italian sausage, tender green peppers and onions, our signature gourmet cheese blend and homemade tomato sauce wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1480 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/cheesymeatballstromboli.jpg",
                        Name = "Cheesy Meatball",
                        Description = "Sliced meatballs, spicy Italian sausage, sauteed onions and green peppers, our signature gourmet cheese blend and homemade tomato sauce wrapped in a goldenbrown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1580 cal."
                    },
                    new Product
                    {
                        Category = cs[1],
                        CategoryID = cs[1].CategoryID,
                        Price = 4.00m,
                        SRC = "/imgs/classicstromboli.jpg",
                        Name = "Classic",
                        Description = "Mild Italian sausage, piping hot meatballs, tender onions and red bell peppers, and our signature gourmet cheese blend smothered in homemade tomato sauce and wrapped in a golden-brown crust, brushed with rich garlic butter and sprinkled Parmesan cheese",
                        Calories = "1385 cal."
                    },
                    new Product
                    {
                        Category = cs[3],
                        CategoryID = cs[3].CategoryID,
                        Price = 2.50m,
                        SRC = "/imgs/classicChickenCaesar.jpg",
                        Name = "Classic Chicken Caesar",
                        Description = "Romaine, all-natural chicken breast, parmesan, crouton, caesar dressing",
                        Calories = "680 cal."
                    },
                    new Product
                    {
                        Category = cs[3],
                        CategoryID = cs[3].CategoryID,
                        Price = 2.50m,
                        SRC = "//imgs/choppedAntiPasto.jpg",
                        Name = "Chopped Antipasto",
                        Description = "Romaine, pepperoni, mozzarella, grape tomato, black olive, banana pepper, red onion, red wine vinegar and olive oil vinagrette",
                        Calories = "620 cal."
                    },
                    new Product
                    {
                        Category = cs[3],
                        CategoryID = cs[3].CategoryID,
                        Price = 2.50m,
                        SRC = "/imgs/baconblu.jpg",
                        Name = "Bacon & Blu",
                        Description = "Romaine, bacon, red onion, grape tomato, goat cheese, blue cheese dressing",
                        Calories = "420 cal."
                    },
                    new Product
                    {
                        Category = cs[3],
                        CategoryID = cs[3].CategoryID,
                        Price = 2.50m,
                        SRC = "/imgs/bonelesswings.jpg",
                        Name = "Boneless Wings",
                        Description = "Choose Buffalo or BBQ sauce",
                        Calories = "300-670 cal."
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/BigRedSoda.jpg",
                        Name = "Big Red",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/MountainDew.jpg",
                        Name = "Mountain Dew",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/MountainDewVoltage.jpg",
                        Name = "Mountain Dew Voltage",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/Nehi Peach Soda.jpg",
                        Name = "Nehi Peach",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/Fanta.jpg",
                        Name = "Fanta",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/OrangeCreamSoda.jpg",
                        Name = "Orange Cream",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    },
                    new Product
                    {
                        Category = cs[4],
                        CategoryID = cs[4].CategoryID,
                        Price = 1.50m,
                        SRC = "/imgs/strawberry-cream-soda-16oz.jpg",
                        Name = "Strawberry Cream",
                        Description = "",
                        Calories = "750 Cal/Liter"
                    }
                     });
                _context.SaveChanges();
            }
        }
        // GET api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var products = await _context.Products.ToListAsync<Product>();
            if (products == null) { return NotFound("records not found."); }
            return Ok(products);
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _cr.Get(id);
            // error check for status 
            if (product == null) { return NotFound("record not found."); }
            return Ok(await _cr.Get(id));
        }

        // POST api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product dto)
        {
            var result = await _cr.Add(dto);
            // error check for status 
            if (result == null) { return BadRequest("Product was not created."); }
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Product dto)
        {
            Product product = await _cr.Update(dto);
            // error check for status 
            if (product == null) { return NotFound("record not found."); }
            return Ok(product);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _cr.Delete(id);
            // error check for status 
            if (product == null) { return NotFound("record not found."); }
            return Ok(new KeyValuePair<string, Product>("Product deleted", product));

        }
    }
}
