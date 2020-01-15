import React from 'react';
import {Link} from "react-router-dom";
import { Icon } from 'antd';
import UserLogo from '../../../assets/avatar.jpg';
import './Header.less';

const Header = () => {
    return (
        <div className='header'>
            <div className='header-container'>
                <Link to='/'><p className='title'>Erer</p></Link>
                <nav className='navigation'>
                    <Link to='/blogs/edit'>
                        <Icon type="edit" />
                        <p className='write-blog'>写博客</p>
                    </Link>
                    <img className='user-logo' src={UserLogo} alt='This image is not exist!'/>
                    <Icon type="caret-down" />
                </nav>
            </div>
        </div>
    )
}

export default Header;