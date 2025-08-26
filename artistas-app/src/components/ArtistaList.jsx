import { useState, useEffect } from 'react';

function ArtistaList() {
    const [artistas, setArtistas] = useState([])
    useEffect(() => {
        fetch("http://localhost:5056/api/artista")
            .then(response => {
                if (!response.ok) {
                    throw new Error("Erro ao buscar dados da API");
                }
                return response.json();
            })
            .then(data => setArtistas(data)).catch(error => console.error('Erro: ', error))
    }, [])

    return (
        <div>
            <h1>Artistas</h1>
            {artistas.map(artista => (
                <div key={artista.id} className="artista-card">
                    <h2>{artista.nome}</h2>
                    <h3>Músicas:</h3>
                    <ul>
                        {artista.musicas.map(musica => (
                            <li key={musica.id}>
                                {musica.nome} ({musica.anoLancamento})
                            </li>
                        ))}
                    </ul>
                </div>
            ))}
        </div>
    )

}
export default ArtistaList;