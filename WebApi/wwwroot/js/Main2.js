let dog_list = [];

const container = document.getElementById("container");
fetch('api/SubTask')
    .then(response => {
        if (response.ok) {
            return response.json();
        } else {
            throw new Error(response.statusText);
        }
    })
    .then(data => {
        dog_list = data;
        console.log(data.)
        for (dog in dog_list) {
            let li = document.createElement("li");
            let node = document.createTextNode(dog);
            li.appendChild(node);
            container.appendChild(li);
        }
    });
