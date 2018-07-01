using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using CMSApp.Models;
using CMSApp.Models.DataAccessLayer;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CMSApp.Controllers
{
    public class ContactsMVController : Controller
    {
        private ContactContext db = new ContactContext();
        private HttpClient client;
        string url = "http://localhost:62842/api/Contacts";
        public ContactsMVController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: ContactsMV
        public async Task<ActionResult> Index()
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(responseData);
                    return View(contacts);
                }
                return View("Error");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: ContactsMV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Contact contact = new Contact();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var actionUrl = $"{url}/{id}";
                HttpResponseMessage responseMessage = await client.GetAsync(actionUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<Contact>(responseData);
                    if (contact == null)
                    {
                        return HttpNotFound();
                    }
                    return View(contact);
                }
                return View("Error");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: ContactsMV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsMV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Status")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, contact);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        //contacts = JsonConvert.DeserializeObject<List<Contact>>(responseData);
                        //return View(contacts);
                        return RedirectToAction("Index");
                    }
                    return View("Error");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: ContactsMV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            Contact contact = new Contact();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var actionUrl = $"{url}/{id}";
                HttpResponseMessage responseMessage = await client.GetAsync(actionUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<Contact>(responseData);
                    if (contact == null)
                    {
                        return HttpNotFound();
                    }
                    return View(contact);
                }
                return View("Error");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: ContactsMV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Status")] Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var actionUrl = $"{url}/{contact.Id}";
                    HttpResponseMessage responseMessage = await client.PutAsJsonAsync(actionUrl, contact);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index");
                    }
                }
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: ContactsMV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Contact contact = new Contact();
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var actionUrl = $"{url}/{id}";
                HttpResponseMessage responseMessage = await client.GetAsync(actionUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    contact = JsonConvert.DeserializeObject<Contact>(responseData);
                    if (contact == null)
                    {
                        return HttpNotFound();
                    }
                    return View(contact);
                }
                return View("Error");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: ContactsMV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id, string setStatusTo)
        {
            Contact contact = new Contact();
            try
            {
                var actionUrl = $"{url}/{id}?setStatusTo={setStatusTo}";
                HttpResponseMessage responseMessage = await client.DeleteAsync(actionUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
