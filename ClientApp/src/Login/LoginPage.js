import React, { Component } from 'react';
import Logar from '../Login/Logar';
import { withRouter } from "react-router-dom";
import './Login.css';
import queryString from 'query-string';


class LoginPage extends Component {
    displayName = LoginPage.name

    constructor(props) {
        super(props);
        this.state = {
            token: this.props.match.params.token,
            params: queryString.parse(this.props.location.search),
        }
    }


    render() {
        return (
            <div>
                <Logar history={this.props.history}
                    user={this.state.params.user}
                    token={this.state.params.token}
                />
            </div>
        );
    }


}
export default withRouter(LoginPage);
