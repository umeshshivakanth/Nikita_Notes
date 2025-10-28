function editRow(button) {
    const row = button.closest('tr');
    row.querySelectorAll('.display-mode').forEach(e => e.style.display = 'none');
    row.querySelectorAll('.edit-mode').forEach(e => e.style.display = 'inline-block');
}

function cancelRow(button) {
    const row = button.closest('tr');
    row.querySelectorAll('.display-mode').forEach(e => e.style.display = '');
    row.querySelectorAll('.edit-mode').forEach(e => e.style.display = 'none');
}

async function saveRow(button) {
    const row = button.closest('tr');
    const tds = row.querySelectorAll('td');

    const title = tds[0].querySelector('input').value.trim();
    const content = tds[1].querySelector('input').value.trim();
    const priority = tds[2].querySelector('select').value;

   
    if (!title || !content || !priority) {
        let message = "Please fill out the following fields:\n";
        if (!title) message += "- Title\n";
        if (!content) message += "- Content\n";
        if (!priority) message += "- Priority\n";
        alert(message);
        return; 
    }

    const data = new URLSearchParams();
    data.append('Id', row.dataset.id);
    data.append('Title', title);
    data.append('Content', content);
    data.append('Priority', priority);

    try {
        const response = await fetch('/Note/EditAjax', {
            method: 'POST',
            body: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });

        if (!response.ok) throw new Error('Something went wrong');

        location.reload();

    } catch (error) {
        console.error('Error saving note:', error);
        alert('Error saving note!');
    }
}
