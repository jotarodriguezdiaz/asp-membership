$(function () {
    // Cuando haga hover sobre el atributo 
    $('[data-admin-menu]').hover(function () {
        $('[data-admin-menu]').toggleClass('open');
    });
});