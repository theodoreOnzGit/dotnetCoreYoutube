using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dotnetTest.Models;

// for random number generator model
using dotnetTest.Models.RNG;


namespace dotnetTest.Pages;

public class testPageModel : PageModel
{
    private readonly ILogger<testPageModel> _logger;

    private IBuns _buns;
    private IPatty _patty;
    private IOther _other;

    // so this part is for testing dependency injection 
    // to spot differences between singleton, scoped and transient
    //

    private IRNGTransient _transientRNG1;
    private IRNGTransient _transientRNG2;
    private IRNGScoped _scopedRNG1;
    private IRNGScoped _scopedRNG2;
    private IRNGSingleton _singletonRNG1;
    private IRNGSingleton _singletonRNG2;


    public testPageModel(ILogger<testPageModel> logger,
		    IBuns buns,
		    IPatty patty,
		    IOther other,
		    IRNGTransient transientRNG1,
		    IRNGTransient transientRNG2,
		    IRNGScoped scopedRNG1,
		    IRNGScoped scopedRNG2,
		    IRNGSingleton singletonRNG1,
		    IRNGSingleton singletonRNG2)
    {
        _logger = logger;
	_buns = buns;
	_patty = patty;
	_other = other;

	// for dependency injection test between scoped, 
	// transient and singleton
        _transientRNG1 = transientRNG1;
        _transientRNG2 = transientRNG2;
        _scopedRNG1 = scopedRNG1;
        _scopedRNG2 = scopedRNG2;
        _singletonRNG1 = singletonRNG1;
        _singletonRNG2 = singletonRNG2;
    }

    public void OnGet()
    {
	    ChickenBurger burger = new ChickenBurger(_patty,
			    _buns,_other);

	    ViewData["cost"] = burger.cost();

    }

    public void OnPostRNG(){

	    ViewData["transientRNG1"] = _transientRNG1.Value;
	    ViewData["transientRNG2"] = _transientRNG2.Value;
	    ViewData["scopedRNG1"] = _scopedRNG1.Value;
	    ViewData["scopedRNG2"] = _scopedRNG2.Value;
	    ViewData["singletonRNG1"] = _singletonRNG1.Value;
	    ViewData["singletonRNG2"] = _singletonRNG2.Value;
    }

}
