

const toggleTask = (taskId) => {
    fetch(`/ToDo/Toggle/${taskId}`, {
        method: "PUT"
    }).then(() => {
        location.reload();
    });
}

const deleteTask = (taskId) => {
    fetch(`/ToDo/Delete/${taskId}`, {
        method: "DELETE"
    }).then(() => {
        location.reload();
    });
}