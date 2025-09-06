import useSidebar from "../../hooks/useSidebar";
import SidebarNav from "./SidebarNav";
import Logo from "../../assets/logo.svg";
import { Link } from "react-router-dom";

const Sidebar = () => {
  const { isOpen } = useSidebar();

  return (
    <nav className={`sidebar ${!isOpen ? "collapsed" : ""}`}>
      <div className="sidebar-content">
          <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/clientes/listagem">Clientes</Link></li>
            <li><Link to="/clientes/criar">Novo Cliente</Link></li>
          </ul>
          <a className="sidebar-brand" href="/" style={{backgroundColor: "#f4f7f9"}}>
            <img src={Logo} height={50} width={200} />
          </a>
          <SidebarNav />
      </div>
    </nav>
  );
};

export default Sidebar;
