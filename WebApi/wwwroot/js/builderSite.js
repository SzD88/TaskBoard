 

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