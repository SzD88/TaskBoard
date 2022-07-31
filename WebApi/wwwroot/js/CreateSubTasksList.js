 const list_el = document.querySelector("#subTasks"); // EditProject.html
 
function createSubtaskList(subTasksObjects) { // it is almost prepered 

    console.log(subTasksObjects);
    const task_el = document.createElement('div');

    task_el.classList.add('subTask');

    const task_content_el = document.createElement('div');

    task_content_el.classList.add('subTaskContent');  // should be changed

    task_el.appendChild(task_content_el);

    //pseudocod:

    //Strona projektowa: ma podtaski:

    //mam liste obiektów2 - subTasksObjects
    //dla kazdego z obiektow2
    //wykonaj funkcja1:
 //      // ale to jest lista obiektow bez generycznego id

    for (nextTask in subTasksObjects) {
        var currentTask = subTasksObjects[nextTask]; 
      var geten =  func1(currentTask);
        task_content_el.appendChild(geten);
        console.log(task_content_el);
    }
    list_el.appendChild(task_el);
    function func1(input)
    {
        var tempList = [];
        const genericDivObject = document.createElement('input');
        genericDivObject.setAttribute('value', input.content);
        genericDivObject.setAttribute('id', input.id);
        genericDivObject.type = 'text';

        const newNode = document.createTextNode(input.content);
        genericDivObject.appendChild(newNode);

      //   console.log("controla jakosci 1  " + input.includedTasks[1].id);

        var includedTasks = input.includedTasks;
      //   console.log(includedTasks);
        for (numberOf in includedTasks)
        {
          //  console.log("controla jakosci 2" + includedTasks[numberOf].id);  // dobre zczytuje 

            var selectedSingle = includedTasks[numberOf];
            
           // console.log("controla jakosci 3" + selectedSingle);
            var getenDIV = func1(selectedSingle)
            //const genericDivObject2 = document.createElement('input');
            //genericDivObject2.setAttribute('value', selectedSingle.content);
            //genericDivObject2.setAttribute('id', selectedSingle.id);
            //genericDivObject2.type = 'text';


            //const nextRandomElementDIV = document.createElement('div');

            //nextRandomElementDIV.appendChild(selectedSingle.content);

            //nextRandomElementDIV.classList.add(selectedSingle.id);

            //genericDivObject.appendChild(nextRandomElementDIV);

             

        }
        return genericDivObject;
    }
     


    async function createSubTaskBasedOnAboveId(levelAboveId, content) {


        var subTaskJSON = createSubTaskJSON(levelAboveId, content); //works

        var url = "/api/SubTask";

        try {
            const config = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: subTaskJSON // JSON.stringify(data)
            }
            const response = await fetch(url, config);
            //const json = await response.json()
            if (response.ok) {
                //return json
                console.log(response);
                return response
            } else {
                //
            }
        } catch (error) {
            //
        }
    }

    function createSubTaskJSON(levelAboveId, content) {
        var subTaskJSON =
        {
            "content": content,
            "levelAboveId": levelAboveId
        }
        const subTaskString = JSON.stringify(subTaskJSON);
        return subTaskString;
    }



}