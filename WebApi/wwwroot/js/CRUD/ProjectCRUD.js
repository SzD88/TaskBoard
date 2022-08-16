// main url
var url = "/api/Project";

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