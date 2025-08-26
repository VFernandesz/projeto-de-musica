function editArtist() {
    //atualizar o artista com o id 1
    const artistaAtualizado = {
        id: 1,
        nome: "Led Zeppelin (Versão Estúdio)",
        musicas: [
            { id: 101, nome: "Stairway to Heaven", anoLancamento: 1971 },
            { id: 102, nome: "Whole Lotta Love", anoLancamento: 1969 }
        ]
    };

    fetch('http://localhost:5056/api/artista/1', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(artistaAtualizado)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao atualizar o artista.');
            }
            console.log('Artista atualizado com sucesso!');
        })
        .catch(error => {
            console.error('Houve um erro:', error);
        });
}