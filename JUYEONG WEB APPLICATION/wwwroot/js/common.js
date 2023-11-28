
function alterByToast(heading, text, icon) {
    $.toast({
        heading: heading,
        text: text,
        showHideTransition: 'slide',
        icon: icon,
        loader: false,
        position: 'top-right'
    });
}