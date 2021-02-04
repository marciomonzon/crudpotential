import React, { useEffect, useState } from 'react';
import { Nav, Navbar, Table, Button } from 'react-bootstrap';
import api from '../../services/Api';
import moment from 'moment';

interface IDesenvolvedor {
    desenvolvedorId: number,
    nome: string,
    idade: number,
    sexo: string,
    hobby: string,
    dataDeNascimento: Date
}

const Desenvolvedores: React.FC = () => {

    const [desenvolvedores, setDesenvolvedores] = useState<IDesenvolvedor[]>([])

    useEffect(() => {
        carregarDesenvolvedores();
    }, []);

    async function carregarDesenvolvedores() {

        const response = await api.get('/developers?page=1');
        console.log(response);
        setDesenvolvedores(response.data)
    }

    async function carregarDesenvolvedoresPaginado(pagina: number) {

        const response = await api.get('/developers?page=' + pagina);
        console.log(response);
        setDesenvolvedores(response.data)
    }

    function formatarDataDeNascimento(dataDeNascimento: Date) {
        return moment(dataDeNascimento).format("DD/MM/YYYY");
    }

    return (
        <div className="container text-center">
            <br/>
            <h3>Desenvolvedores</h3>
            <br/>
            <Table striped bordered hover>
                <thead>                 
                    <tr>
                        <th>#</th>
                        <th>Nome</th>
                        <th>Idade</th>
                        <th>Sexo</th>
                        <th>Hobby</th>
                        <th>Data de Nascimento</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        desenvolvedores.map(d => (
                            <tr key={ d.desenvolvedorId }>
                                <td>{ d.desenvolvedorId }</td>
                                <td>{ d.nome }</td>
                                <td>{ d.idade }</td>
                                <td>{ d.sexo }</td>
                                <td>{ d.hobby }</td>
                                <td>{ formatarDataDeNascimento(d.dataDeNascimento) }</td>
                                <td>
                                    <Button size="sm">Editar</Button>{' '}
                                    <Button size="sm" variant="success">Finalizar</Button>{' '}
                                    <Button size="sm" variant="info">Visualizar</Button>{' '}
                                    <Button size="sm" variant="danger">Remover</Button>{' '}
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </Table>
                    
            <Button href="#">Anterior</Button> <Button href="#">Proximo</Button> 
        </div>
    );
    
}

export default Desenvolvedores;