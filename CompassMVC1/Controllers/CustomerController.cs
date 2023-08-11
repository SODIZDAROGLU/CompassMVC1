using CompassMVC1.Data;
using CompassMVC1.Models.Domain;
using CompassMVC1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompassMVC1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly compassMVCdbContext mvcCompassDbContext;

        public CustomerController(compassMVCdbContext mvcCompassDbContext)
        {
            this.mvcCompassDbContext = mvcCompassDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        //customerList
        public async Task<IActionResult> Index()
        {
            //mvcCompassDbContext = access for the employee folder
            var customers = await mvcCompassDbContext.Customers.ToListAsync();
            return View(customers);
        }

        [HttpPost]
        // add new customer
        public async Task<IActionResult> Add(AddCustomerModel model)
        {
            var customer = new CustomerModel()
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Booking = model.Booking,
                PassportNumber = model.PassportNumber,
                TicketNumber = model.TicketNumber,
                TicketFee = model.TicketFee,
                Tax = model.Tax,
                Commission = model.Commission,
                Total = model.Total,
                RecordDate = model.RecordDate,
                Note = model.Note,
            };

            await mvcCompassDbContext.Customers.AddAsync(customer);
            await mvcCompassDbContext.SaveChangesAsync();

            return RedirectToAction("Index");//Index = after saving takes you to customerList
        }
        



        [HttpGet]
        //calling update view with edit button
        public async Task<IActionResult> Edit(int id)
        {

            var customer = await mvcCompassDbContext.Customers.FirstOrDefaultAsync(x => x.ID == id);
            if (customer != null)
            {
                var viewModal = new UpdateCustomerModel()
                {
                    ID = customer.ID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Booking = customer.Booking,
                    PassportNumber = customer.PassportNumber,
                    TicketNumber = customer.TicketNumber,
                    TicketFee = customer.TicketFee,
                    Tax = customer.Tax,
                    Commission = customer.Commission,
                    Total = customer.Total,
                    RecordDate = customer.RecordDate,
                    Note = customer.Note
                };
                //return await Task.Run(()=>View(viewModal));
                return View(viewModal);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        //update
        public async Task<IActionResult> Edit(UpdateCustomerModel model)
        {
            var customer = await mvcCompassDbContext.Customers.FindAsync(model.ID);
            if (customer != null)
            {
                customer.ID = model.ID;
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Booking = model.Booking;
                customer.PassportNumber = model.PassportNumber;
                customer.TicketNumber = model.TicketNumber;
                customer.TicketFee = model.TicketFee;
                customer.Tax = model.Tax;
                customer.Commission = model.Commission;
                customer.Total = model.Total;
                customer.RecordDate = model.RecordDate;
                customer.Note = model.Note;

                await mvcCompassDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCustomerModel model)
        {
            var customer = await mvcCompassDbContext.Customers.FindAsync(model.ID);
            if (customer != null)
            {
                mvcCompassDbContext.Customers.Remove(customer);
                await mvcCompassDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

    }
}
