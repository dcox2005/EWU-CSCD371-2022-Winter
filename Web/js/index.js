

function menuDropdown() 
{
    document.getElementById("menuDropdown").classList.toggle("Menu-dropdown-show");
}

window.onclick = function(event) 
{
    if (!event.target.matches('.Menu-button')) 
    {
        var dropdowns = document.getElementsByClassName("Menu-dropdown");
        var i;
        for (i = 0; i < dropdowns.length; i++) 
        {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('Menu-dropdown-show')) 
            {
                openDropdown.classList.remove('Menu-dropdown-show');
            }
        }
    }
}