var name = "Inigo Montoya";
var person = {
    name: "Inigo Montoya",
    age: function () {
        return new Date().getFullYear() - this.year;
    },
    year: 1987,
    weapon: "sword",
    getName: function () {
        return this.name;
    }
};

function showName() {
    console.log(this.name);
}
console.log("Hello World: " + person.getName() + " is " + person.age());

document.getElementById("mybutton").addEventListener("click", function () {
    console.log("Hello World: " + person.getName() + " is " + person.age());
});

axios({
    method: 'get',
    url: 'https://api.openweathermap.org/data/2.5/weather?units=imperial&lat=47.658&lon=-117.402&appid=e44ff6715c0c7c9bf43ce3bfe74fdb6f'
})
    .then(function (response) {
        console.log(response);
        console.log(response.data.main.temp);

        let weatherText = document.querySelector(".weather");
        weatherText.innerText = "Current Temp: " + response.data.main.temp;
    })
    .catch(function (error) {
        console.log(error);
    });
