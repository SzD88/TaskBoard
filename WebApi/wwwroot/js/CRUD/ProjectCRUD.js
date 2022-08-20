// main url
var url = "/api/Project";
 

//GET ALL PROJECTS 
async function getAllProjects() {
 var dataToReturn =  fetch('api/Project') //get by default
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error(response.statusText);
            }
        })
        .then(data => {
            return data
        });
    return dataToReturn;
}

//GET ALL PROJECTS SORTED
async function getAllProjectsSortedByAttribute(attribute) {

    var attributeJson = {
        "SortField": attribute,
        "Ascending": true 
    }
    const config = {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: attributeJson   
    }
    var dataToReturn = fetch('api/Project', config) //get by default
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error(response.statusText);
            }
        })
        .then(data => {
            return data
        });
    return dataToReturn;
}

//POST
async function CreateProject(title, description, projectNumber) { // ok

    var projJson = createJSON(title, description, projectNumber); //works
     
    try {
        const config = {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: projJson // JSON.stringify(data)
        }
        const response = await fetch(url, config);
        if (response.ok) {
            console.log(response);
            return response
        } else {

        }
    } catch (error) {

    }
}
//PUT
async function putDataFromFieldsToDatabase(projecId, projectNumber, title, description) {

    var projJson = createJSON(title, description, projectNumber); //works

    var url = "/api/Project";

    try {
        const config = {
            method: 'PUT', //#projectput
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: projJson // JSON.stringify(data)
        }
        const response = await fetch(url, config);
        if (response.ok) {
            console.log(response);
            return response
        } else {

        }
    } catch (error) {

    }
}
//CREATE EXAMPLES
function createExampleProjects() {
    fetch("/api/Project/CreateExamples", { method: 'POST' });
    location.reload(true);
};

//GET SORTING FIELDS
 async function getSortFields() {
   let x = await fetch("/api/Project/GetSortFields" );

     let arrayOfSortFields = await x.json(); //array
     return arrayOfSortFields;
};