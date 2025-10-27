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

    const data = new URLSearchParams();
    data.append('Id', row.dataset.id);
    data.append('Title', tds[0].querySelector('input').value);
    data.append('Content', tds[1].querySelector('input').value);
    data.append('Priority', tds[2].querySelector('select').value);

    try {
        const response = await fetch('/Note/EditAjax', {
            method: 'POST',
            body: data,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        });

        if (!response.ok) throw new Error('Network response was not ok');

        // Refresh the page to show updated data
        location.reload();
    } catch (error) {
        console.error('Error saving note:', error);
        alert('Error saving note!');
    }
}