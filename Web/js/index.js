/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function menuDropdown() {
    document.getElementById("menuDropdown").classList.toggle("Menu-dropdown-show");
  }
  
  // Close the dropdown menu if the user clicks outside of it
  window.onclick = function(event) {
    if (!event.target.matches('.Menu-button')) {
      var dropdowns = document.getElementsByClassName("Menu-dropdown");
      var i;
      for (i = 0; i < dropdowns.length; i++) {
        var openDropdown = dropdowns[i];
        if (openDropdown.classList.contains('Menu-dropdown-show')) {
          openDropdown.classList.remove('Menu-dropdown-show');
        }
      }
    }
  }