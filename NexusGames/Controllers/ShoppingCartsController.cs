using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexusGames.Data;
using NexusGames.Models;

namespace NexusGames.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // אנחנו מחפשים את המשתמש הראשון הקיים במערכת
            var gamer = await _context.Gamers.FirstOrDefaultAsync();
            if (gamer == null) return View(new ShoppingCart { CartItems = new List<CartItem>(), TotalPrice = 0 });

            var cart = await _context.ShoppingCart
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Game)
                .FirstOrDefaultAsync(c => c.GamerId == gamer.Id && !c.IsPurchased);

            if (cart == null)
            {
                return View(new ShoppingCart { CartItems = new List<CartItem>(), TotalPrice = 0 });
            }

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToShoppingCart(int gameId)
        {
            // 1. ננסה למצוא משתמש קיים
            var gamer = await _context.Gamers.FirstOrDefaultAsync();

            // 2. אם אין אף משתמש, ניצור אחד (בלי להגדיר ID ידנית)
            if (gamer == null)
            {
                gamer = new Gamer
                {
                    Username = "Ariel",
                    Email = "ariel@example.com",
                    CreditCard = "123456789",
                    DateOfBirth = DateTime.Now.AddYears(-20)
                };
                _context.Gamers.Add(gamer);
                await _context.SaveChangesAsync(); // SQL ייתן לו ID כאן
            }

            // 3. מציאת עגלה פעילה למשתמש שמצאנו/צרנו
            var cart = await _context.ShoppingCart
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.GamerId == gamer.Id && !c.IsPurchased);

            // 4. אם אין עגלה, יצירת חדשה
            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    GamerId = gamer.Id,
                    TotalPrice = 0,
                    IsPurchased = false
                };
                _context.ShoppingCart.Add(cart);
                await _context.SaveChangesAsync();
            }

            // 5. מציאת המשחק והוספה לעגלה
            var game = await _context.Games.FindAsync(gameId);
            if (game == null) return NotFound();

            var item = new CartItem
            {
                ShoppingCartId = cart.Id,
                GameId = gameId
            };

            _context.CartItems.Add(item);
            cart.TotalPrice += (int)game.Price;

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "המשחק נוסף לסל הקניות בהצלחה!";

            return RedirectToAction("Index", "Games");
        }

        // שאר הפעולות (Details, Delete) נשארות כפי שהיו
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var shoppingCart = await _context.ShoppingCart
                .Include(c => c.CartItems).ThenInclude(ci => ci.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null) return NotFound();
            return View(shoppingCart);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            if (shoppingCart != null)
            {
                _context.ShoppingCart.Remove(shoppingCart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}