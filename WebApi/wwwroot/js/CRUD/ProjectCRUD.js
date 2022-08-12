//post

async function CreateProject(title, description, projectNumber) {

    var projJson = createJSON(title, description, projectNumber); //works

    var url = "/api/Project";

    try {
        const config = {
            method: 'PUT',
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