using System;
using System.Collections.Generic;
// contains Include()
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoSeller.Models;
using AutoSeller.ViewModel;

namespace AutoSeller.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        // Adding new or editing old customer
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //in the form we don't give an Id, thats why we set it as hidden before the submit button (see CustomerForm)
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);

            }
            else
            {
                //in this way we limit the properties of the customer which will be edited
                //otherwise we can use Mapper.Map(customer, customerInDb); in order to map all properties
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;


            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // GET: Customers/Details
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault( element => element.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        /*       public IEnumerable<Customer> GetCustomers()
               {
                   var customers = new List<Customer>
                   {
                       new Customer {Id = 1, Name = "John Smith" },
                       new Customer {Id = 2, Name = "Mary Williams" }

                   };

                   return customers;
               }
        */
    }
}