import React, { Component } from 'react';
import { Route, Switch, Router } from 'react-router-dom';
import Header from './BlogManage/components/Header/Header';
import Homepage from './BlogManage/pages/Homepage/Homepage';
import BlogDetail from './BlogManage/pages/BlogDetail/BlogDetail';
import BlogEdit from './BlogManage/pages/BlogEdit/BlogEdit';
import BlogManage from './BlogManage/pages/BlogManage/BlogManage';
import history from './history';
import './App.less';

class App extends Component {
    render() {
        return (
            <Router history={history}>
                <div className='app'>
                    <Header />
                    <div className='page-container'>
                        <Switch>
                            <Route exact path='/blogs/manage' component={BlogManage} />
                            <Route exact path='/blogs/edit/:id?' component={BlogEdit} />
                            <Route exact path='/blogs/:id' component={BlogDetail} />
                            <Route exact path='/' component={Homepage} />
                        </Switch>
                    </div>
                </div>
            </Router >
        );
    }
}

export default App;
