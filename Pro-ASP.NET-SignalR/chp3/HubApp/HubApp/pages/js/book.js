const bookHub = $.connection.BookHub;
bookHub.client.signalError = exception => {
    const message = exception ? exception.Message : "Undefined Exception";
    $('#alert').slideDown();
    $('#message').text(message);
    console.error(`Signal Exception: ${message}`, exception);
};

$.connection.hub.start().done(() => {
    bookHub.server
            .getBook(1)
            .done(book => setBook(book))
            .fail(err => console.error('SignalR::GetBook', JSON.stringify(err)));

    bookHub.server
        .getCategories()
        .done(cats => {                      
            cats.forEach(cat => $('#cats').append(`<li class='list-group-item'>${cat.Category}</li>`));
        })
        .fail(err => console.error('SignalR::GetCategories', err));
});

function setBook(book) {
    $('#bookId').val(book.BookId);
    $('#title').text(book.Title);
    $('#author').text(book.Author);
    $('#bookImg').attr('src', book.Img);
    $('#edition').text(book.Edition);
    $('#pages').text(book.Pages);
    $('#category').text(book.Category.Category);
    $('#subcategory').text(book.Subcategory.Subcategory);
    $('#language').text(book.Language);
    $('#price').text(book.Price);
    $('#alert').slideUp();
}

function getBook(bookId) {
    bookHub.server.getBook(bookId).done(book => {        
        $('#bookId').val(bookId);
        setBook(book)
    }).catch(err => console.error('SingnalR', err));
}

function prevBook() {
    let bookId = $('#bookId').val();
    bookId = bookId <= 1 ? 1 : --bookId;
    getBook(bookId);
}

function nextBook() {
    let bookId = $('#bookId').val();
    bookId++;
    getBook(bookId);
}