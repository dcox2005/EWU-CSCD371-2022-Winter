var name = "Inigo Montoya";
var person = {
    name: "Inigo Montoya",
    age: function() {
        todaysYear = new Date().getFullYear()
        return todaysYear - this.year;
    },
    year: 1987,
    weapon: "sword",
    getName: function(){
        return this.name;
    },
};

function showName(){
    console.log(this.name);
}

console.log("hello world: " + person.getName() + " is " + person.age());

// document.getElementById("mybutton").innerHTML = person.getName();
document.getElementById("mybutton").addEventListener("click", function(){
    console.log("hello world: " + person.getName() + " is " + person.age());
})