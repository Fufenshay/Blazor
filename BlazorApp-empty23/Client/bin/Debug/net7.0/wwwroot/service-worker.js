/* Manifest version: +ALUEitI */
self.addEventListener('fetch', event => {
    event.respondWith(
        caches.match(event.request)
            .then(response => {
                if (response) {
                    return response;
                }
                return fetch(event.request)
                    .then(networkResponse => {
                        if (!networkResponse.ok) {
                            console.error("Network response was not ok:", networkResponse.status, networkResponse.url);
                            throw new Error('Network response was not ok');
                        }
                        return networkResponse;
                    })
                    .catch(error => {
                        console.error("Fetch error:", error, event.request.url);
                        // ������� �����-�� ����� �� ��������� ��� ���������� ��������� �� ������
                        return new Response('<h1>Error</h1>', {
                            status: 500,
                            headers: { 'Content-Type': 'text/html' }
                        });
                    });
            })
    );
});