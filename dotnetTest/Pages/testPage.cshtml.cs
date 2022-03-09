using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotnetTest.Models;

namespace dotnetTest.Pages;

public class testPageModel : PageModel
{
    private readonly ILogger<testPageModel> _logger;

    private IBuns _buns;
    private IPatty _patty;
    private IOther _other;

    public testPageModel(ILogger<testPageModel> logger,
		    IBuns buns,
		    IPatty patty,
		    IOther other)
    {
        _logger = logger;
	_buns = buns;
	_patty = patty;
	_other = other;
    }

    public void OnGet()
    {
	    ChickenBurger burger = new ChickenBurger(_patty,
			    _buns,_other);

	    ViewData["cost"] = burger.cost();

    }
}
