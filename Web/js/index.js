
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

function punchLine()
{
   let answerplace = document.querySelector(".Answer");
   answerplace.style.visibility = 'visible'
}


function getJoke()
{
   axios
   ({
      method: 'get',
      url: 'https://v2.jokeapi.dev/joke/Programming'
   })
   .then(function (response) 
   {
      // console.log(response);
      let type = response.data.type;
      // console.log(type);
      let placement = document.querySelector(".Joke");
      if(type.includes("single", 0) )
      {
         let joke = response.data.joke
         placement.innerText = joke;
      }
      else if (type.includes("twopart", 0)) //type "twopart"
      {
         let setup = response.data.setup;
         let delivery = response.data.delivery;
         placement.innerText = setup;
         let answerplace = document.querySelector(".Answer");
         answerplace.style.visibility = 'hidden'
         answerplace.innerText = delivery;
   
         setTimeout(punchLine, 4000);
      }
      else
      {
         placement.innerText = "Try again in a few moments";
      }
   })
   .catch(function (error) 
   {
      console.log("error: try again in a few moments.");
   });

}   

window.onload = getJoke;