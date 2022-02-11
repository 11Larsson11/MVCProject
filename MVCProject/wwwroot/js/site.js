
function GetViewAll(getURL) {

    $.get(getURL, function (data) {

        $('#displayPersons').html(data);
    });
}


function GetDeleteID(getURL) {
    const id = document.getElementById('IdInput').value;
    PostDelete(getURL, id);
}

function PostDelete(getURL, id) {
    $.post(getURL, { id: id }, function (data) {
        $('#displayPersons').html(data);
    })
}


function GetDetailsID(getURL) {
    const id = document.getElementById('IdInput').value;
    PostDetails(getURL, id);
}

function PostDetails(getURL, id) {
    $.post(getURL, { id: id }, function (data) {
        $('#displayPersons').html(data);
    })
}





