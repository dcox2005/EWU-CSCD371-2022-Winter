
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

axios
({
   method: 'get',
   url: 'https://v2.jokeapi.dev/joke/Programming'
})
.then(function (response) 
{
   console.log(response);
   let type = response.data.type;
   console.log(type);
   let placement = document.querySelector(".Joke");
   if(type.includes("single", 0) )
   {
      let joke = response.data.joke
      placement.innerText = joke;
   }
   else  //type "twopart"
   {
      let setup = response.data.setup;
      let delivery = response.data.delivery;
      placement.innerText = setup + "\n";
      setTimeout(punchLine, 4000);
   }
})
.catch(function (error) 
{
   console.log(error);
});

function punchLine(placement, delivery)
{
   placement.innerText = delivery;
}
