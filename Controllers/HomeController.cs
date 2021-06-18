using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using AsyncShopBridge.Models;

namespace AsyncShopBridge.Controllers
{
	public class ShopBridgeController : Controller
	{
		private ShopBridgeContext shopBridgeContext = new ShopBridgeContext();
		public async Task<ActionResult> Index()
		{
			return View(await shopBridgeContext.ShopItems.ToListAsync());
		}


		public ActionResult Create()
		{
			return View(new ShopItem());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(ShopItem shopItem)
		{
			if (ModelState.IsValid)
			{
				UpdateModel(shopItem);
				shopBridgeContext.ShopItems.Add(shopItem);
				await shopBridgeContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(shopItem);
		}

		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ShopItem shopItem = await shopBridgeContext.ShopItems.FindAsync(id);
			if (shopItem == null)
			{
				return HttpNotFound();
			}

			return View(shopItem);
		}


		public async Task<ActionResult> Edit(int? id)
		{

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ShopItem shopItem = await shopBridgeContext.ShopItems.FindAsync(id);
			if (shopItem == null)
			{
				return HttpNotFound();
			}

			return View(shopItem);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(ShopItem shopItem)
		{
			if (ModelState.IsValid)
			{
				shopBridgeContext.Entry(shopItem).State = EntityState.Modified;
				await shopBridgeContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(shopItem);
		}

		public async Task<ActionResult> Delete(int? id)
		{

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ShopItem shopItem = await shopBridgeContext.ShopItems.FindAsync(id);
			if (shopItem == null)
			{
				return HttpNotFound();
			}

			return View(shopItem);
		}


		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete_Confirmed(int id)
		{
			ShopItem dept = await shopBridgeContext.ShopItems.FindAsync(id);
			shopBridgeContext.ShopItems.Remove(dept);
			await shopBridgeContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				shopBridgeContext.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}