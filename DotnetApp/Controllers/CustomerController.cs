using DotnetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using DotnetApp.Models;
using DotnetApp.Repositories.RepositoriesContracts;
namespace DotnetApp.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

public class CustomerController : Controller
{
    //injection du repo correspondant
    
    private readonly ICustomerRepository _customerRepository;
    private readonly IMembershiptypeRepository _MembershipTypeRepository;

    public CustomerController(ICustomerRepository customerRepository, IMembershiptypeRepository membershipTypeRepository)
    {
        this._customerRepository = customerRepository;
        this._MembershipTypeRepository = membershipTypeRepository;
    }


    //les methodes

    public IActionResult Index()
    {
        return View(_customerRepository.GetAll());
    }

    // afficher la vue pour ajout de client
    [HttpGet]
    public IActionResult Add()
    {
        var members = _MembershipTypeRepository.GetAll();
        ViewBag.member = members.Select(members => new SelectListItem()
        {
            Text = members.Name.ToString(),
            Value = members.Name.ToString()
        });
        return View();
    }

    //ajout de client lors de la soumission du formulaire
    [HttpPost]
    public IActionResult Add(Customer customer) 
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        _customerRepository.Add(customer);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(Guid id)
    {
        var members = _MembershipTypeRepository.GetAll();
        ViewBag.member = members.Select(members => new SelectListItem()
        {
            Text = members.Id.ToString(),
            Value = members.Id.ToString() 
        });

        return View(_customerRepository.Get(id));
    }

    public IActionResult Details(Guid id)
    {
        try
        {
            var customer = _customerRepository.Get(id);

            return View(customer);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    public IActionResult SaveCanchges(Customer customer)
    {
        _customerRepository.Update(customer);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(Guid id)
    {
        _customerRepository.Delete(_customerRepository.Get(id));
        return RedirectToAction("Index");

    }





}