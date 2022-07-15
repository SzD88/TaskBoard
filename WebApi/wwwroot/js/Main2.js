let dog_list = [];

const container = document.getElementById("container");

import Tasks from '/api/SubTask'

const allTasks = fetch('api/SubTask')
    .then(response => response.json())
    .then(tasks => {
        for (i in tasks) {
          //  console.log(tasks[i].id)
        }
    });

for (t in Tasks) {
    console.log(t);
}

    //{
    //    if (response.ok) {
    //        return response.json();
    //    } else {
    //        throw new Error(response.statusText);
    //    }
    //})
    //.then(data => {
    //    dog_list = data;
    //    console.log(data.)
    //    for (dog in dog_list) {
    //        let li = document.createElement("li");
    //        let node = document.createTextNode(dog);
    //        li.appendChild(node); 
    //        container.appendChild(li);
    //    }
    //});
