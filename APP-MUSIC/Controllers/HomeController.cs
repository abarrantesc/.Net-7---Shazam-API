using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using APP_MUSIC.Models;
using API_MUSIC.Interface;
using API_MUSIC.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Dynamic;

namespace APP_MUSIC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public readonly IMusic music = new MusicRepository();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index2()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public IActionResult Index()
    {

        return View();
    }

    public async Task<IActionResult> Songs(string SearchWord)
    {
        try
        {
                var data = await music.SearchSongAsync(SearchWord);

                return View(data);
       

        }
        catch (Exception ex)
        {
            var error = "error";
            return Json(error);

        }
    }

    public async Task<IActionResult> GetSongDetail(int id)
    {

        try
        {
                var data = await music.GetSongsDetailsAsync(id);
                return View(data);

        }
        catch (Exception ex)
        {
            return View();
        }

       

    }
}

