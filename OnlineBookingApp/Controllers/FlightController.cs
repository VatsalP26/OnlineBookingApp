using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookingApp.Data;
using OnlineBookingApp.Models.Booking;
using System.Linq;
using System.Threading.Tasks;

public class FlightController : Controller
{
    private readonly OnlineBookingDbContext _context;

    public FlightController(OnlineBookingDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string airline, DateTime? arrivalTime)
    {
        // Retrieve flights based on search parameters
        IQueryable<Flight> flights = _context.flights;

        if (!string.IsNullOrEmpty(airline))
        {
            flights = flights.Where(f => f.Airline.Contains(airline));
        }

        //if (arrivalTime.HasValue)
        //{
        //    flights = flights.Where(f => f.ArrivalTime.Date == arrivalTime.Value.Date);
        //}

        // Return filtered flights to the view
        return View(await flights.ToListAsync());
    }


    // GET: Flight/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.flights.FirstOrDefaultAsync(m => m.FlightId == id);
        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

    // GET: Flight/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Flight/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FlightId,Airline,DepartureTime,ArrivalTime,Price")] Flight flight)
    {
        if (ModelState.IsValid)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    // GET: Flight/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.flights.FindAsync(id);
        if (flight == null)
        {
            return NotFound();
        }
        return View(flight);
    }

    // POST: Flight/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("FlightId,Airline,DepartureTime,ArrivalTime,Price")] Flight flight)
    {

        Flight flt = await _context.flights.FirstOrDefaultAsync(x => x.FlightId == id);

        if(flt == null)
        {
            return NotFound();
        }

        else
        {
            flt.Airline = flight.Airline;
            flt.ArrivalTime = flight.ArrivalTime;
            flt.DepartureTime = flight.DepartureTime;
            flt.Price = flight.Price;
            try
            {
                _context.Update(flt);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(flight.FlightId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(flight);
    }

    // GET: Flight/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var flight = await _context.flights.FirstOrDefaultAsync(m => m.FlightId == id);
        if (flight == null)
        {
            return NotFound();
        }

        return View(flight);
    }

    // POST: Flight/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var flight = await _context.flights.FindAsync(id);
        _context.flights.Remove(flight);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }



    [HttpPost]
    public async Task<IActionResult> Book(int flightId)
    {
        // Retrieve the flight based on the flightId
        var flight = await _context.flights.FindAsync(flightId);
        if (flight == null)
        {
            return NotFound();
        }

        // Create a new GuestBooking instance
        var booking = new GuestBooking
        {
            FlightId = flightId,
           
        };

    
        _context.guestBooking.Add(booking);
        await _context.SaveChangesAsync();

        // Redirect to a view with a confirmation message
        return RedirectToAction("BookingConfirmation");
    }

    public IActionResult BookingConfirmation()
    {
        // Display a view with a confirmation message
        return View();
    }

    private bool FlightExists(int id)
    {
        return _context.flights.Any(e => e.FlightId == id);
    }


}
