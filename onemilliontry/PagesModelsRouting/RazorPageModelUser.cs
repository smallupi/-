// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Razor;
// using Microsoft.AspNetCore.Mvc.RazorPages;

// namespace onemilliontry
// {
    
//     public class RootModel:PageModel{
//         private readonly UserDBModel _context;
//         public RootModel(UserDBModel context)
//         {
//             _context = context;
//         }
//         public IList<User>Users{get;set;} = default!;

//         public IActionResult OnGet(){
//             return Page();
//         }

//         public async Task OnGetAsync(){
//             if(_context.Users !=null)
//             {
//                 Users = await _context.Users.ToListAsync();
//             }
//         }
//     }
//     public async Task<IActionResult> OnPostAsync()
//     {
//         if(!ModelState.IsValid)
//         {
//             return Page();
//         }
//         _context.User.Add(User);
//         await _context.SaveChangeAsync();

//         return RedirectToPage("/Index");
//     }
    
// }