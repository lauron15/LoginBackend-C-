import React, { useState, useCallback } from 'react';
import { Redirect } from 'react-router';
import { Link } from 'react-router-dom';
import { useCookies } from 'react-cookie'
import cookie from 'react-cookies';
import { ToastContainer, toast } from 'react-toastify';

export default function Logar(props) {

    const [cookies, setCookie, removeCookie] = useCookies(['access_token'])
    const [cpfCns, setCpfCns] = useState("");
    const [atoken, setAtoken] = useState("");

    const [senha, setSenha] = useState("");
    const [redirect, setRedirect] = useState(false);





    function handleErrors(response) {

        toast.configure();
        if (!response.ok) {
            response.json().then(r => toast.error(r.descricao));
        } else {

            setCookie('cpfCns', cpfCns, { path: '/' });

            response.json().then(data => {
                setCookie('usuario', data, { path: '/' });
                setCookie('access_token', data.token, { path: '/' });

            }).then(setRedirect(true));



        }
        return response;
    }

    var initialState = (event) => {

        event.preventDefault();
        event.stopPropagation();

        const requestOptions = {

            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                nome: cpfCns,
                senha: senha,
            })
        };
        fetch('api/account', requestOptions).then(handleErrors);
    };

    if (props.user && props.token) {
        /*  removeCookie("cpfCns");
          removeCookie("access_token");
          removeCookie("usuario");*/
        setCookie('cpfCns', props.user, { path: '/' });
        setCookie('access_token', props.token, { path: '/' });
        setCookie('usuario', { nomeUsuario: props.user }, { path: '/' });
        return <Redirect push to="/" />;

    }


    if (redirect) {
        return <Redirect push to="/" />;
    }

    return (
        <form id="form1" runat="server" onSubmit={initialState} >
            <div className="container">
                <div className="row">
                    <div className="col"></div>
                    <div className="col-4 ">

                        <div className="account-wall form">
                            <img className="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120"
                                alt="" />
                            <h1 className="text-center login-title">Assistência Social</h1>

                            <div className="form-signin">

                                <input id="_edtCpfCns" name="cpfCns" type="text" placeholder="Informe o nome de usuário" className="form-control input-md" autoFocus required value={cpfCns} onChange={(e) => setCpfCns(e.target.value)} />
                                <input id="_edtSenha" name="senha" type="password" placeholder="Senha" className="form-control input-md" required value={senha} onChange={(e) => setSenha(e.target.value)} />
                                <div className="form-group">
                                    <button type="submit" id="_btnEntrar" name="_btnEntrar" className="btn btn-block btn-primary"   >Entrar</button>
                                </div>

                            </div>
                        </div>

                    </div>
                    <div className="col"></div>
                </div>
            </div>
        </form>
    );
}
