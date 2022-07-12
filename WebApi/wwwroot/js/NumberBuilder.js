 
//window.onload = myFunction();

const item =  //  "Create/{floor}") 
{
    number1: '',
    operator: '',
    number2: ''
   
}

const answer =  //  "Create/{floor}") 
{
answer: 'zz'
}
 

function addFloor() // number 1
{
 //   const addItemTextbox = document.getElementById('add-floor'); // nvm co
    const addNameTextbox = document.getElementById('add-floor');

    item.number1 = parseInt(addNameTextbox.value.trim());
    
}

function addWall() // operator 
{
    const addItemTextbox = document.getElementById('add-wall'); // nvm co

    item.operator = addItemTextbox.value.trim();
    
}
function addRoof() { // number 2
    const addItemTextbox = document.getElementById('add-roof'); // nvm co

    item.number2 = parseInt(addItemTextbox.value.trim());

}

function myFunction()
{
    addFloor();
    addWall();
    addRoof();
}

function myFunction2() {
    var ans = answer.answer ;
    var floor = item.number1;
    var wall = item.operator;
    var roof = item.number2;
    document.getElementById("myAnswer").innerHTML = ans;
    document.getElementById("myText").innerHTML = floor;
    document.getElementById("myText2").innerHTML = wall;
    document.getElementById("myText3").innerHTML = roof;
}

function buildHouse() { 
    console.log(item);
    var cos =
        fetch('https://localhost:7088/CalculateDecimal', // https://localhost:7088/CalculateDecimal
            {
                method: 'POST',
                headers:
                {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(item)
            }) /// ten obiekt jako funkcja jest juz zwrotem! To jest obiekt zwrocony sam
            // w sobie 
            .then(response => response.json()) // tutaj robisz z niego jsona!!
            // tutaj uzywasz ten obiekt jako stringa
            .then(data => answer.answer = data )

            .then(data => console.log(data))

            
          
          .catch(error => console.error('Unable to add item.', error));
        

    
}