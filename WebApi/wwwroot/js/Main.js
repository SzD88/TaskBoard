

window.addEventListener('load', () => {
    const form = document.querySelector("#new-task-form");
   const input = document.querySelector("#new-task-input");
   const list_el = document.querySelector("#tasks");


    form.addEventListener('submit', (e) => {
        e.preventDefault();
        const task = input.value; // zmienna przypisana do task pobrana z pola
        if (!task) {
            alert("Wpisz treść przed dodaniem");
            return;
        }  

        const task_el = document.createElement("div"); //  tworzy kontener
        task_el.classList.add("task");  // przypisuje element do contenera
         // a wiec mozna do niego juz cos pobrac z api?

        const task_content_el = document.createElement("div");
        task_content_el.classList.add("content"); // to Z Tasks1 - content
        task_content_el.innerText = task;

        task_el.appendChild(task_content_el);

        const task_input_el = document.createElement("input"); // input to typ html o typie text
        task_input_el.classList.add("text");
        task_input_el.type = "text";
        task_input_el.value = task;
        task_input_el.setAttribute("readonly", "readonly");

        task_content_el.appendChild(task_input_el); // appendchild po prostu dodaje element na koniec istniejacej w html listy ...

        list_el.appendChild(task_el);




    })     
})
 
const item =  //  "Create/{floor}") 
{
    floors: '',
    walls: '',
    roof: ''
}

const numbers =  //  "Create/{floor}") 
{
    number1: '',
    operator: '',
    number2: ''
}
 

function addFloor()
{
 //   const addItemTextbox = document.getElementById('add-floor'); // nvm co
    const addNameTextbox = document.getElementById('add-floor');

    item.floors = addNameTextbox.value.trim();
    
}

function addWall()
{
    const addItemTextbox = document.getElementById('add-wall'); // nvm co

    item.walls = addItemTextbox.value.trim();
    
}
function addRoof() {
    const addItemTextbox = document.getElementById('add-roof'); // nvm co

    item.roof = addItemTextbox.value.trim();

}

function myFunction()
{
    addFloor();
    addWall();
    addRoof();
}

function myFunction2() {
    var floor = item.floors;
    var wall = item.walls;
    var roof = item.roof;
    document.getElementById("myText").innerHTML = floor;
    document.getElementById("myText2").innerHTML = wall;
    document.getElementById("myText3").innerHTML = roof;
}

function buildHouse() { 

    fetch('api/BuildHouse', // https://localhost:7066/api/buildhouse/create/floor
        {
            method: 'POST',
            headers:
            {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(item)
        })
        .then(response => Response.json())
        .then(() => {
            //  getItems();
           
        })
        .catch(error => console.error('Unable to add item.', error));

}