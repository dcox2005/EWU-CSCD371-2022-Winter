
let dropdownBtn = document.querySelector('.Menu-button');
let menuContent = document.querySelector('.Menu-dropdown');
dropdownBtn.addEventListener('click',()=>{
   if(menuContent.style.display==="")
   {
      menuContent.style.display="block";
   } 
   else 
   {
      menuContent.style.display="";
   }
})