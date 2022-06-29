window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 5000 });
    }

    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 5000 });
    }
}

window.ShowSawl = (type, message) => {
    if (type === "success") {
        Swal.fire({
            icon: 'success',
            title: 'Success Notification!',
            text: message            
        })
    }

    if (type === "error") {
        Swal.fire({
            icon: 'error',
            title: 'Error Notification!',
            text: message    
        })
    }
    if (type === "warning") {
        Swal.fire({
            icon: 'warning',
            title: 'warning Notification!',
            text: message
        })
    }
}